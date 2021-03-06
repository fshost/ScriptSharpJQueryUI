// Events.cs
// Script#/samples/jQuery.UI/jQuery.UI.Sample/Draggable
// Copyright (c) Ivaylo Gochkov, 2012
// This source code is subject to terms and conditions of the Apache License, Version 2.0.
//

using jQueryApi;
using jQueryApi.UI.Interactions;

namespace Sample.Draggable
{
    internal static class Events
    {
        static Events()
        {
            jQuery.OnDocumentReady(delegate()
            {
                jQueryObject start_counter = jQuery.Select("#event-start");
                jQueryObject drag_counter = jQuery.Select("#event-drag");
                jQueryObject stop_counter = jQuery.Select("#event-stop");
                int[] counts = new int[] { 0, 0, 0 };

                DraggableOptions options = new DraggableOptions();
                options.Start = delegate(jQueryEvent e, DragStartEvent eventData)
                {
                    counts[0]++;
                    UpdateCounterStatus(start_counter, counts[0]);
                };
                options.Drag = delegate(jQueryEvent e, DragEvent eventData)
                {
                    counts[1]++;
                    UpdateCounterStatus(drag_counter, counts[1]);
                };
                options.Stop = delegate(jQueryEvent e, DragStopEvent eventData)
                {
                    counts[2]++;
                    UpdateCounterStatus(stop_counter, counts[2]);
                };

                jQuery.Select("#draggableEvents")
                    .Plugin<DraggableObject>()
                    .Draggable(options);

                
            });
        }

        static void UpdateCounterStatus(jQueryObject event_counter, int new_count)
        {

            // first update the status visually...
            if (!event_counter.HasClass("ui-state-hover"))
            {
                event_counter.AddClass("ui-state-hover")
                             .Siblings().RemoveClass("ui-state-hover");
            }

            // ...then update the numbers
            jQuery.Select("span.count", event_counter)
                  .Text(new_count.ToString());
        }
    }
}
